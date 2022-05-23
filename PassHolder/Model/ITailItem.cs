namespace PassHolder.Model
{
    public interface ITailItem
    {
        public string AppName { get; set; }
        public string AppLogin { get; set; }
        public string AppPass { get; set; }
        public string? AppUri { get; set; }
    }
}
