using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellToolDK
{
    class FrameCalculator
    {
        public static int Frame(TifFileInfo fi)
        {
            //get Values
           
            int fr = fi.frame + 1;
            int Zstack = fi.zValue + 1;
            int ColorStack = fi.cValue + 1;

            int ColorStackCount = fi.sizeC;
            int ZstackCount = fi.sizeZ;
           
            //Calculate
            int newFr = (fr - 1) * ColorStackCount * ZstackCount +
                (Zstack * ColorStackCount - (ColorStackCount - ColorStack)) - 1;
           
            //Return results
            return newFr;
        }
        public static int FrameC(TifFileInfo fi,int C)
        {
            //get Values

            int fr = fi.frame + 1;
            int Zstack = fi.zValue + 1;
            int ColorStack = C + 1;

            int ColorStackCount = fi.sizeC;
            int ZstackCount = fi.sizeZ;

            //Calculate
            int newFr = (fr - 1) * ColorStackCount * ZstackCount +
                (Zstack * ColorStackCount - (ColorStackCount - ColorStack)) - 1;

            //Return results
            return newFr;
        }
        public static int[] FrameCalculateTZ(TifFileInfo fi, int C, int imageN)
        {
            int ColorStack = C + 1;
            int ColorStackCount = fi.sizeC;
            int ZstackCount = fi.sizeZ;
            for (int i = fi.cValue; i < fi.imageCount; i+= fi.sizeC)
                for (int fr = 1; fr <= fi.sizeT; fr++)
                    for (int Zstack = 1; Zstack <= ZstackCount; Zstack++)
                    {
                        //Calculate
                        int newFr = (fr - 1) * ColorStackCount * ZstackCount +
                            (Zstack * ColorStackCount - (ColorStackCount - ColorStack)) - 1;
                        //Return results
                        if (newFr == imageN)
                        {
                            return new int[] {fr-1, Zstack - 1 };
                        }
                    }
            return new int[] { 0, 0};
        }

    }
}
