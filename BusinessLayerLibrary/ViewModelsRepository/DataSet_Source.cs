using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayerLibrary.ViewModelsRepository
{
    public class DataSet_Source
    {
        public long Id { get; set; }

        public string TableStorageName { get; set; }
        public string AccountKey { get; set; }
        public string AccountName { get; set; }
    }
}
