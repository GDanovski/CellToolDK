﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace CellToolDK
{
    public class TifFileInfo
    {
        public double zoom = 1;
        public double Xposition = 0;
        public double Yposition = 0;
        //Chart
        public int xAxisTB = 0;
        public int yAxisTB = 0;
        //RoiManager
        public List<ROI>[] roiList = null;
        public int ROICounter = 0;
        //Tracking
        public int[] tracking_MaxSize;
        public int[] tracking_MinSize;
        public int[] tracking_Speed;
        /// <summary>
        /// Segmentation
        /// </summary>
        //filter history
        public List<int> FilterHistory = new List<int>();
        //controls
        public int DataSourceInd = 0;
        public int[] SegmentationProtocol;
        public int[] SegmentationCBoxIndex;
        public int[] thresholdsCBoxIndex;
        public bool[] sumHistogramChecked;
        //spotdetector controls
        public int[] SpotThresh;
        public Color[] SpotColor;
        public Color[] RefSpotColor;
        public int[] SelectedSpotThresh;
        public int[] typeSpotThresh;
        public string[] SpotTailType;
        public int[] spotSensitivity;
        //specific values
        public int[] thresholds;
        public int[][] thresholdValues;
        public Color[][] thresholdColors;
        public Color[][] RefThresholdColors;
        //BandC
        public bool autoDetectBandC = false;
        public bool applyToAllBandC = false;
        //
        public int selectedPictureBoxColumn = 0;
        //History
        public List<string> History = new List<string>();
        public int HistoryPlace = -1;
        public bool undo = false;
        public bool redo = false;
        public bool delHist = false;
        //info var
        public int frame = 0;
        public int zValue = 0;
        public int cValue = 0;
        public bool original = true;
        //Not available
        public bool loaded = false;
        public bool available = true;
        public bool selected = false;
        public int openedImages = 0;
        //tif image
        public byte[][][] image8bit;
        public ushort[][][] image16bit;
        public byte[][][] image8bitFilter;
        public ushort[][][] image16bitFilter;
        //tif tags
        public string Dir;
        public int seriesCount;
        public int imageCount;
        public int sizeX;
        public int sizeY;
        public int sizeZ;
        public double umZ;
        public double umXY;
        public int sizeC;
        public int sizeT;
        public int bitsPerPixel;
        public string dimensionOrder;
        public int pixelType;
        public bool FalseColored;
        public bool isIndexed;
        public bool MetadataComplete;
        public string DatasetStructureDescription;
        public List<Color> LutList;
        public List<Double> TimeSteps;
        public double Micropoint=0;
        //Metadata protocol info
        public string FileDescription="";
        public int xCompensation = 0;
        public int yCompensation = 0;
        //properties
        public int[][] histogramArray = null;
        public int[] MinBrightness = null;
        public int[] MaxBrightness = null;
        public float[][] adjustedLUT = null;
       
        public void Delete()
        {
            image8bit = null;
            image16bit = null;
            History.Clear();
        }
        public string toString()
        {
            string info = "";
            info += ("Series count: " + seriesCount.ToString());
            info += ("\nFirst series:");
            info += ("\nImage count = " + imageCount.ToString());
            info += ("\nSizeX = " + sizeX.ToString());
            info += ("\nSizeY = " + sizeY.ToString());
            info += ("\nSizeXY(um) = " + umXY.ToString());
            info += ("\nSizeZ = " + sizeZ.ToString());
            info += ("\nSizeZ(um) = " + umZ.ToString());
            info += ("\nSizeC = " + sizeC.ToString());
            info += ("\nSizeT = " + sizeT.ToString());
            info += ("\nBitsPerPixel = " + bitsPerPixel.ToString());
            info += ("\ndimensionOrder = " + dimensionOrder);
            info += ("\npixelType = " + pixelType.ToString());
            info += ("\nFalseColored = " + FalseColored.ToString());
            info += ("\nIndexed = " + isIndexed.ToString());
            info += ("\nMetadataComplete = " + MetadataComplete.ToString());
            info += ("\nDatasetStructureDescription = ") + DatasetStructureDescription;
            info += ("\nLut color list = ");
            for (int i = 0; i < LutList.Count; i++)
            {
                if(i > 0) { info += ";"; }
                info += System.Drawing.ColorTranslator.ToHtml(LutList[i]).Replace("\n","");
            }
            if (TimeSteps != null)
            {
                info += ("\nTimeSteps = ");
                for (int i = 0; i < TimeSteps.Count; i++)
                {
                    if (i > 0) { info += ";"; }
                    info += TimeSteps[i].ToString();
                }
            }
            info += ("\nMicropoint = ") + Micropoint.ToString();
            info += ("\nFileDescription = ") + FileDescription;
            return info;
        }
    }
}