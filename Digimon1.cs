using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Digimon1.Enums;
using Attribute = Digimon1.Enums.Attribute;

namespace Digimon1
{
    public class Digimon1Entry
    {
        public short id;
        public DigimonNames digimonName;
        public short chrId;
        public short evoListPos;
        public Level level;
        public Attribute attribute;
        public float scale;
        public float combatSpeed;
        public Special special1;
        public Special special2;
        public Special special3;
        public byte unk4;
        public float unk5;
        public float unk6;
        public float initialY;
        public float minY;
        public float maxY;
        public float initialZ;
        public float minZ;
        public float maxZ;
        public float initialRotation;
        public float digiviceScale;
        public float unk7;
        public float unk8;
        public short unk9;
        public short unk10;
        public float unk11;
        public float unk12;
        public byte unk13;
        public byte unk14;
        public short unk15;
        public short unk16;
        public short unk17;
        public short unk18;
        public short unk19;
        public byte[] skills;
        public short finisher;
        public short unk37;
        public short unk38;
        public short unk39;
        public short unk40;
        public short unk41;
        public float unk42;
        public float unk43;
        public float unk44;
        public float unk45;
        public float unk46;
        public float unk47;
        public float unk48;
        public float unk49;
        public float unk50;


        public Digimon1Entry(BinaryReader br)
        {
          
                id = br.ReadInt16();
                digimonName = (DigimonNames)id;
                chrId = br.ReadInt16();
                evoListPos = br.ReadInt16();
                level = (Level)br.ReadByte();
                attribute = (Attribute)br.ReadByte();
                scale = br.ReadSingle();
                combatSpeed = br.ReadSingle();
                special1 = (Special)br.ReadByte();
                special2 = (Special)br.ReadByte();
                special3 = (Special)br.ReadByte();
                unk4 = br.ReadByte();
                unk5 = br.ReadSingle();
                unk6 = br.ReadSingle();
                initialY = br.ReadSingle();
                minY = br.ReadSingle();
                maxY = br.ReadSingle();
                initialZ = br.ReadSingle();
                minZ = br.ReadSingle();
                maxZ = br.ReadSingle();
                initialRotation = br.ReadSingle();
                digiviceScale = br.ReadSingle();
                unk7 = br.ReadSingle();
                unk8 = br.ReadSingle();
                unk9 = br.ReadInt16();
                unk10 = br.ReadInt16();
                unk11 = br.ReadSingle();
                unk12 = br.ReadSingle();
                unk13 = br.ReadByte();
                unk14 = br.ReadByte();
                unk15 = br.ReadInt16();
                unk16 = br.ReadInt16();
                unk17 = br.ReadInt16();
                unk18 = br.ReadInt16();
                unk19 = br.ReadInt16();
                skills = br.ReadBytes(16);
                finisher = br.ReadInt16();
                unk37 = br.ReadInt16();
                unk38 = br.ReadInt16();
                unk39 = br.ReadInt16();
                unk40 = br.ReadInt16();
                unk41 = br.ReadInt16();
                unk42 = br.ReadSingle();
                unk43 = br.ReadSingle();
                unk44 = br.ReadSingle();
                unk45 = br.ReadSingle();
                unk46 = br.ReadSingle();
                unk47 = br.ReadSingle();
                unk48 = br.ReadSingle();
                unk49 = br.ReadSingle();
                unk50 = br.ReadSingle();
            }

        public void write(BinaryWriter bw)
            {
                bw.Write((short)id);
                bw.Write(chrId);
                bw.Write(evoListPos);
                bw.Write((byte)level);
                bw.Write((byte)attribute);
                bw.Write(scale);
                bw.Write(combatSpeed);
                bw.Write((byte)special1);
                bw.Write((byte)special2);
                bw.Write((byte)special3);
                bw.Write(unk4);
                bw.Write(unk5);
                bw.Write(unk6);
                bw.Write(initialY);
                bw.Write(minY);
                bw.Write(maxY);
                bw.Write(initialZ);
                bw.Write(minZ);
                bw.Write(maxZ);
                bw.Write(initialRotation);
                bw.Write(digiviceScale);
                bw.Write(unk7);
                bw.Write(unk8);
                bw.Write(unk9);
                bw.Write(unk10);
                bw.Write(unk11);
                bw.Write(unk12);
                bw.Write(unk13);
                bw.Write(unk14);
                bw.Write(unk15);
                bw.Write(unk16);
                bw.Write(unk17);
                bw.Write(unk18);
                bw.Write(unk19);
                bw.Write(skills);
                bw.Write(finisher);
                bw.Write(unk37);
                bw.Write(unk38);
                bw.Write(unk39);
                bw.Write(unk40);
                bw.Write(unk41);
                bw.Write(unk42);
                bw.Write(unk43);
                bw.Write(unk44);
                bw.Write(unk45);
                bw.Write(unk46);
                bw.Write(unk47);
                bw.Write(unk48);
                bw.Write(unk49);
                bw.Write(unk50);
            }
        }
    }

