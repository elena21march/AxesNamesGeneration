using System.Collections.Generic;
using Data.Enums;
using Rhino.Geometry;

namespace AxesNamesGeneration
{
    public partial class UBlock
    {
        public string Id { get; set; }
        public List<House> Houses { get; set; }
        public List<Parking> Parkings { get; set; }
        public Courtyard Courtyard { get; set; }
        public Plane BasePlane { get; set; }
        public Tep Tep { get; set; }
        public List<Element> Elements { get; set; }
        public ComfortClass ComfortClass { get; set; }
        public List<PBlock> ParkingBlocks { get; set; }

    }

    public partial class Plane
    {
        public Point3d Origin { get; set; }
        public double OriginX { get; set; }
        public double OriginY { get; set; }
        public double OriginZ { get; set; }
        public Vector3d XAxis { get; set; }
        public Vector3d YAxis { get; set; }
        public Vector3d ZAxis { get; set; }
        public Vector3d Normal { get; set; }
        public bool IsValid { get; set; }
    }

    public partial class Vector3d
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public Autodesk.Revit.DB.XYZ XYZ { get { return new Autodesk.Revit.DB.XYZ(MmToFoot(X), MmToFoot(Y), MmToFoot(Z)); } }
        private double MmToFoot(double length)
        {
            return length / (12 * 25.4);
        }
    }

    public partial class Point3d
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public Autodesk.Revit.DB.XYZ XYZ { get { return new Autodesk.Revit.DB.XYZ(MmToFoot(X), MmToFoot(Y), MmToFoot(Z)); } }
        private double MmToFoot(double length)
        {
            return length / (12 * 25.4);
        }
    }

    public partial class Courtyard
    {
        public string Id { get; set; }
        public Curve Contour { get; set; }
        public List<Element> Elements { get; set; }
        public Plane BasePlane { get; set; }

    }
    /*
    public partial class Curve
    {
        public long Version { get; set; }
        public long Archive3Dm { get; set; }
        public long Opennurbs { get; set; }
        public string Data { get; set; }
    }
    */
    public partial class Element
    {
        public string Id { get; set; }
        public Curve Boundary { get; set; }
        public List<Point3d> Polyline { get; set; }
        public List<Curve> InnerCrvs { get; set; }
        public Plane BasePlane { get; set; }
    }

    public partial class House
    {
        public string Id { get; set; }
        public List<HBlock> HBlocks { get; set; }
    }

    public partial class HBlock : Building
    {

        public Curve HbBoundary { get; set; }
        public int StoreyNum { get; set; }
        public List<Level> Levels { get; set; }
        public Tep Tep { get; set; }
        public List<Window> Windows { get; set; }
        public List<Plane> WindowPlanes { get; set; }
        public List<Facade> Facades { get; set; }
        public List<Element> Elements { get; set; }
    }

    public partial class PBlock : HBlock
    {
    }
    public partial class Window
    {
        public Plane Pl { get; set; }
        public bool Insol { get; set; }
        public WindowType WinType { get; set; }
    }

    public partial class Level : Building
    {
        public string FloorNo { get; set; }
        public List<int> AptTypology { get; set; }
        public LLU Llu { get; set; }
        public Curve Contour { get; set; }
        public double LArea { get; set; }
        public List<Flat> Flats { get; set; }
        public List<Wall> Walls { get; set; }
        public List<Point3d> Mop { get; set; }
        public bool Fake { get; set; } = false;
    }

    public partial class Flat : Building
    {
        public Curve Contour { get; set; }
        public int RoomQty { get; set; }
        public string FlatNo { get; set; }
        public List<Window> FlatWindows { get; set; }
        public double GrossArea { get; set; }
        public double LivingArea { get; set; }
        public int BottomSteps { get; set; }
        public int TopSteps { get; set; }
        public Plane Door { get; set; }
        public bool Fake { get; set; } = false;
    }

    public partial class LLU : Building
    {
        public Plane LlPlane { get; set; }
        public int LiftNumber { get; set; }
        public Curve LlContour { get; set; }
        public double LlArea { get; set; }
    }

    public partial class Parking : Building
    {
        public Curve Contour { get; set; }
        public int UndergroundStoreys { get; set; }
        public int OvergroundStoreys { get; set; }
        public int StoryHeight { get; set; }
        public double OvergroundAreaRatio { get; set; }
        public double UndergroundAreaRatio { get; set; }
        public double GroundAreaRatio { get; set; }
        public int NumberOfCars { get; set; }
        public double Area { get; set; }
        public List<Element> Elements { get; set; }
        public List<Facade> Facades { get; set; }
    }

    public partial class Wall : Building
    {
    }

    public partial class Tep
    {
        public Dictionary<string, string> TepProperties { get; set; }
    }
    public partial class Facade
    {
        public string Id { get; set; }
        public Plane BasePlane { get; set; }
    }
    public class Building
    {
        public string pathRVT { get; set; }
        public string Id { get; set; }
        public Plane BasePlane { get; set; }

    }

    public enum WindowType { Window, Balcony }
}
