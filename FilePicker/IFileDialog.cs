using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FilePicker
{
     interface IFileDialog
    {
         bool Multiselect { get; set; }
         IEnumerable<String> FileNames { get; set; }
    }
}
