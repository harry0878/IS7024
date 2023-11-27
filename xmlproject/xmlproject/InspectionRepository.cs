using InspectionData;

namespace xmlproject
{
    public class InspectionRepository
    {
        static InspectionRepository()
        {
            allInspectionDetails = new List<Inspection>();
        }

        public static IList<Inspection> allInspectionDetails { get; set; }
    }
}

