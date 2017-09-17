//using NUnit.Framework;

//namespace Cake.Docker.Tests.Ps
//{
//    public class DockerPsParserTest
//    {
//		public class Indexes
//        {
//			[TestFixture]
//			public class CreateFromFirstLine
//            {
//                [Test]
//                public void WhenShortLine_Parses()
//                {
//                    var actual = DockerPsParser.Indexes.CreateFromFirstLine(
//@"CONTAINER ID        IMAGE                         COMMAND                  CREATED             STATUS                       PORTS               NAMES");

//                    Assert.That(actual.ImageIndex, Is.EqualTo(20));
//                    Assert.That(actual.CommandIndex, Is.EqualTo(50));
//                    Assert.That(actual.CreatedIndex, Is.EqualTo(75));
//                    Assert.That(actual.StatusIndex, Is.EqualTo(95));
//                    Assert.That(actual.PortsIndex, Is.EqualTo(124));
//                    Assert.That(actual.NameIndex, Is.EqualTo(144));
//                    Assert.That(actual.SizeIndex.HasValue, Is.False);
//                }

//                [Test]
//                public void WhenSizeIncludedLine_Parses()
//                {
//                    var actual = DockerPsParser.Indexes.CreateFromFirstLine(
//@"CONTAINER ID        IMAGE                         COMMAND                  CREATED             STATUS                        PORTS               NAMES             SIZE");

//                    Assert.That(actual.SizeIndex, Is.EqualTo(163));
//                }
//            }
//        }

//		[TestFixture]
//		public class ParseLine
//        {
//            [Test]
//            public void WhenNormalLineNoPorts_ParsesId()
//            {
//                var indexes = DockerPsParser.Indexes.CreateFromFirstLine("CONTAINER ID        IMAGE                         COMMAND                  CREATED             STATUS                       PORTS               NAMES");
//                var actual = DockerPsParser.ParseLine(indexes, 
//					"012250884ff2        busybox                       \"sh\"                     3 seconds ago       Created                                          xul");

//                Assert.That(actual.Id, Is.EqualTo("012250884ff2"));
//            }
//            [Test]
//            public void WhenNormalLineNoPorts_ParsesImage()
//            {
//                var indexes = DockerPsParser.Indexes.CreateFromFirstLine("CONTAINER ID        IMAGE                         COMMAND                  CREATED             STATUS                       PORTS               NAMES");
//                var actual = DockerPsParser.ParseLine(indexes,
//                    "012250884ff2        busybox                       \"sh\"                     3 seconds ago       Created                                          xul");

//                Assert.That(actual.Image, Is.EqualTo("busybox"));
//            }
//            [Test]
//            public void WhenNormalLineNoPorts_ParsesCommand()
//            {
//                var indexes = DockerPsParser.Indexes.CreateFromFirstLine("CONTAINER ID        IMAGE                         COMMAND                  CREATED             STATUS                       PORTS               NAMES");
//                var actual = DockerPsParser.ParseLine(indexes,
//                    "012250884ff2        busybox                       \"sh\"                     3 seconds ago       Created                                          xul");

//                Assert.That(actual.Command, Is.EqualTo("sh"));
//            }
//            [Test]
//            public void WhenNormalLineNoPorts_ParsesCreated()
//            {
//                var indexes = DockerPsParser.Indexes.CreateFromFirstLine("CONTAINER ID        IMAGE                         COMMAND                  CREATED             STATUS                       PORTS               NAMES");
//                var actual = DockerPsParser.ParseLine(indexes,
//                    "012250884ff2        busybox                       \"sh\"                     3 seconds ago       Created                                          xul");

//                Assert.That(actual.Created, Is.EqualTo("3 seconds ago"));
//            }
//            [Test]
//            public void WhenNormalLineNoPorts_ParsesStatus()
//            {
//                var indexes = DockerPsParser.Indexes.CreateFromFirstLine("CONTAINER ID        IMAGE                         COMMAND                  CREATED             STATUS                       PORTS               NAMES");
//                var actual = DockerPsParser.ParseLine(indexes,
//                    "012250884ff2        busybox                       \"sh\"                     3 seconds ago       Created                                          xul");

//                Assert.That(actual.Status, Is.EqualTo(ContainerStatus.Created));
//            }
//            [Test]
//            public void WhenNormalLineNoPorts_ParsesName()
//            {
//                var indexes = DockerPsParser.Indexes.CreateFromFirstLine("CONTAINER ID        IMAGE                         COMMAND                  CREATED             STATUS                       PORTS               NAMES");
//                var actual = DockerPsParser.ParseLine(indexes,
//                    "012250884ff2        busybox                       \"sh\"                     3 seconds ago       Created                                          xul");

//                Assert.That(actual.Name, Is.EqualTo("xul"));
//            }
//        }

//		[TestFixture]
//		public class ParseContainerStatus
//        {
//            [TestCase("", ExpectedResult =  ContainerStatus.Created)]
//            [TestCase("Exited (0) 3 days ago", ExpectedResult = ContainerStatus.Exited)]
//            [TestCase("Exited (137) 5 months ago", ExpectedResult = ContainerStatus.Exited)]
//            public ContainerStatus WhenGivenText_Parses(string input)
//            {
//                return DockerPsParser.ParseContainerStatus(input);
//            }
//        }

//        [TestFixture]
//        public class ParseExitCode
//        {
//            [TestCase("", ExpectedResult = null)]
//            [TestCase("Exited (0) 3 days ago", ExpectedResult = 0)]
//            [TestCase("Exited (137) 5 months ago", ExpectedResult = 137)]
//            public int? WhenGivenText_Parses(string input)
//            {
//                return DockerPsParser.ParseExitCode(input);
//            }
//        }

//		[TestFixture]
//		public class ParseSize
//        {
//			[TestCase("1.113 MB", ExpectedResult = (long)(1.113m * 1024 * 1024))]
//            [TestCase("0 B", ExpectedResult = 0)]
//            [TestCase("1.557 kB", ExpectedResult = (long)(1.557m * 1024))]
//			public long WhenGivenInput_Parses(string input)
//            {
//                return DockerPsParser.ParseSize(input);
//            }
//        }

//		[TestFixture]
//		public class ParseVirtualSize
//        {
//            [TestCase("0 B (virtual 1.113 MB)", ExpectedResult = (long)(1.113m * 1024 * 1024))]
//            [TestCase("1.557 kB (virtual 133.2 MB)", ExpectedResult = (long)(133.2m * 1024 * 1024))]
//            public long WhenGivenInput_Parses(string input)
//            {
//                return DockerPsParser.ParseVirtualSize(input);
//            }
//        }
//    }
//}
