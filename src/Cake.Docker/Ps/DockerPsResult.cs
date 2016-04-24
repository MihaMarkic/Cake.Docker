namespace Cake.Docker
{
    public class DockerPsResult
    {
        public string Id { get; set; }
        public string Image { get; set; }
        public string Command { get; set; }
        public string Created { get; set; }
        public ContainerStatus Status { get; set; }
        public int? ExitCode { get; set; }
        //public string Ports { get; set; }
        public string Name { get; set; }
        public long? Size { get; set; }
        public long? VirtualSize { get; set; }
    }
}
