namespace Http.Example
{
    using Newtonsoft.Json;

    internal sealed class CreateUserParameters
    {
        public string Name { get; set; }

        public string Job { get; set; }
    }
}
