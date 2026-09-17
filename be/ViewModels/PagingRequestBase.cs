using System.ComponentModel;

namespace THUCTAP.ViewModels
{
    public class PagingRequestBase
    {
        [DefaultValue(1)]
        public int pageIndex { get; set; } = 1;

        [DefaultValue(10)]
        public int pageSize { get; set; } = 10;
    }
}