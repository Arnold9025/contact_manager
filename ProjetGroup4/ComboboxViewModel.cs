using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetGroup4 {
    class ComboboxViewModel {
        public List<String> Option { get; set; }

        public ComboboxViewModel() {
            this.Option = new List<string>()
            { "Family", "Business", "Friend", "Other"};
        }
    }

}
