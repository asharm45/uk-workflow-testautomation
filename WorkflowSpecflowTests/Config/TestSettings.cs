namespace WorkflowSpecflowTests.Config
{
    public class TestSettings
    {
        public string[] Args { get; set; }
        public bool Headless { get; set; }
        public bool DevTools { get; set; }
        public float SlowMo { get; set; }
        public float Timeout { get; set; }
        public string MerlinEnv { get; set; }
        public string DynamicsEnv { get; set; }
        public string ApiUrl { get; set; }
        public DriverType DriverType { get; set; }
        public bool Video { get; set; }
        public bool Trace { get; set; }
        public int MaxRetries { get; set; }

    }

    public enum DriverType
    {
        Edge,
        Chromium,
        Firefox,
        Chrome,
        Webkit
    }
}
