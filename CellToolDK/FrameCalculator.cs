/*
 CellToolDK - CellTool Development Kit
 Copyright (C) 2018  Georgi Danovski

 This program is free software: you can redistribute it and/or modify
 it under the terms of the GNU General Public License as published by
 the Free Software Foundation, either version 3 of the License, or
 (at your option) any later version.

 This program is distributed in the hope that it will be useful,
 but WITHOUT ANY WARRANTY; without even the implied warranty of
 MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 GNU General Public License for more details.

 You should have received a copy of the GNU General Public License
 along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
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
