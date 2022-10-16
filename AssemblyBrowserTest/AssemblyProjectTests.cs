using AssemblyBrowserCore;
using AssemblyBrowserCore.Service;
using NUnit.Framework;

namespace AssemblyBrowserTest
{
    public class AssemblyBrowserTests
    {
        private readonly AssemblyService _assemblyService = new("C:/Users/anton/Desktop/СПП/lab_1/Tracer/TracerLibrary/bin/Debug/net5.0/TracerLibrary.dll");
        private AssemblyInfo _assemblyInfo;

        [SetUp]
        public void Setup()
        {
            _assemblyInfo = _assemblyService.GetAssemblyInfo();
        }

        [Test]
        public void NamespaceCountTest()
        {
            Assert.AreEqual(8, _assemblyInfo.NamespaciesInfos.Count);
        }

        [Test]
        public void NamespaceTitleTest()
        {
            Assert.AreEqual("TracerLibrary.Writer", _assemblyInfo.NamespaciesInfos[0].NamespaceTitle);
        }

        [Test]
        public void TypesCountTest()
        {
            Assert.AreEqual(3, _assemblyInfo.NamespaciesInfos[0].TypeInfo.Count);
        }

        [Test]
        public void HasInterfaceTest()
        {
            string type = _assemblyInfo.NamespaciesInfos[0].TypeInfo[2].Type;

            Assert.AreEqual("Interface", type);
        }
        
        [Test]
        public void HasClassTest()
        {
            string type = _assemblyInfo.NamespaciesInfos[0].TypeInfo[1].Type;

            Assert.AreEqual("Class", type);
        }


        [Test]
        public void MethodInformationPropertiesCountTest()
        {
            int propertiesCount = _assemblyInfo.NamespaciesInfos[2].TypeInfo[0].PropertyInfos.Count;

            Assert.AreEqual(4, propertiesCount);
        }
        
        [Test]
        public void MethodInformationFieldsCountTest()
        {
            int propertiesCount = _assemblyInfo.NamespaciesInfos[2].TypeInfo[0].FieldInfos.Count;

            Assert.AreEqual(0, propertiesCount);
        }

        [Test]
        public void MethodInformationMethodCountTest()
        {
            int propertiesCount = _assemblyInfo.NamespaciesInfos[2].TypeInfo[0].MethodInfos.Count;

            Assert.AreEqual(8, propertiesCount);
        }


        [Test]
        public void FileWriterWriteParametersCountTest()
        {
            int paramsCount = _assemblyInfo.NamespaciesInfos[0].TypeInfo[1].MethodInfos[0].FieldInfos.Count;

            Assert.AreEqual(1, paramsCount);
        }
 
        [Test]
        public void FileWriterWriteStringWriterParamTypeTest()
        {
            string paramType = _assemblyInfo.NamespaciesInfos[0].TypeInfo[1].MethodInfos[0].FieldInfos[0].FieldType;

            Assert.AreEqual("StringWriter", paramType);
        }
        
        [Test]
        public void FileWriterWriteReturnValueTypeTest()
        {
            string returnValueType = _assemblyInfo.NamespaciesInfos[0].TypeInfo[1].MethodInfos[0].ReturnType;

            Assert.AreEqual("Void", returnValueType);
        }
    }
}