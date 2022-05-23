using System;

namespace PassHolder.ViewModel
{
    public interface IViewModel
    {
        public string Title { get; set; }
        public string AppName { get; }
        public Uri PagesSource { get; set; }

        //public abstract IViewModel GetInstance();
    }
}
