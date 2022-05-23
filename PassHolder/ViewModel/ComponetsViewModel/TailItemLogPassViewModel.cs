using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassHolder.ViewModel.ComponetsViewModel
{
    internal class TailItemLogPassViewModel : BaseViewModel
    {
        private List<ItemsOfTail> _listItem;

        public string AppName { get; set; }
        public string AppLogin { get; set; }
        public string AppPass { get; set; }
        public string? AppUrl { get; set; }

        public TailItemLogPassViewModel()
        {
            AppName = "MyApp_1";
            AppLogin = "MyLogin_1";
            AppPass = "MyPass_1";
            AppUrl = "MyUrl_1";
        }

        public List<ItemsOfTail> ListItem
        {
            get {
                return new List<ItemsOfTail>
                {
                    new ItemsOfTail
                    {
                        AppName = "MyApp_1",
                        AppLogin = "MyLogin_1",
                        AppPass = "MyPass_1",
                        AppUrl = "MyUrl_1",
                    },
                    new ItemsOfTail
                    {
                        AppName = "MyApp_2",
                        AppLogin = "MyLogin_2",
                        AppPass = "MyPass_2",
                        AppUrl = "MyUrl_2",
                    },
                };
            }
        }
    }

    internal class ItemsOfTail
    {
        public string AppName { get; set; }
        public string AppLogin { get; set; }
        public string AppPass { get; set; }
        public string? AppUrl { get; set; }
    }
}
