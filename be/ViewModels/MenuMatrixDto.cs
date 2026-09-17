namespace THUCTAP.ViewModels
{
    public class MenuMatrixDto
    {
        public int id { get; set; }
        public string label { get; set; }
        public string icon { get; set; }

        public bool isGranted { get; set; }

        public List<MenuMatrixDto> children { get; set; } = new List<MenuMatrixDto>();
        public List<ActionMatrixDto> action { get; set; } = new List<ActionMatrixDto>();
    }

    public class ActionMatrixDto
    {
        public int id { get; set; }
        public string label { get; set; }
        public string code { get; set; }

        public bool isGranted { get; set; }
    }
}