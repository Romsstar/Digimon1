using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digimon1
{
    public class KCAP
    {
        public char[] magic; //MAGIC "KCAP"
        public int version; //0x00000001
        public int fileSize;
        public int padding;
        public int fileCount;
        public int typeCount;
        public int headerSize;
        public int payloadStart;
        public int[] dataOffset;
        public int[] dataSize;


        //read KCAP
        public KCAP(BinaryReader br)
        {
            magic = br.ReadChars(4);
            version = br.ReadInt32();
            fileSize = br.ReadInt32();
            padding = br.ReadInt32();
            fileCount = br.ReadInt32();
            typeCount = br.ReadInt32();
            headerSize = br.ReadInt32();
            payloadStart = br.ReadInt32();
            dataOffset = new int[fileCount];
            dataSize = new int[fileCount];
            for (int i = 0; i < fileCount; i++)
            {
                dataOffset[i] = br.ReadInt32();
                dataSize[i] = br.ReadInt32();
            }
        }

        //Binary Writer
        public void write(BinaryWriter bw)
        {
            bw.Write(magic);
            bw.Write(version);
            bw.Write(fileSize);
            bw.Write(padding);
            bw.Write(fileCount);
            bw.Write(typeCount);
            bw.Write(headerSize);
            bw.Write(payloadStart);
            for (int i = 0; i < fileCount; i++)
            {
                bw.Write(dataOffset[i]);
                bw.Write(dataSize[i]);
            }
        }
    }
}

