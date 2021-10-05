using CMS.Controllers;
using CMS.Models;
using CMS.Provider;
using CMS.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;


namespace CMSUnitTestProject
{
    
    public class UnitTest1
    {
        Doctor d1;
        Patient p1;
        [SetUp]

        public void Setup()
        {
            d1 = new Doctor();
            p1 = new Patient();
            Mock<IDoctor> mockdrepo = new Mock<IDoctor>();
            Mock<IDocProvider> mockdprovider = new Mock<IDocProvider>();
            DocProvider d = new DocProvider(mockdrepo.Object);
            DoctorsController dc = new DoctorsController(mockdprovider.Object);
            mockdrepo.Setup(r => r.GetDoctorById(1)).Returns(d1);
            mockdprovider.Setup(r => r.GetDoctorById(1)).Returns(d1);
            
            Mock<IPatient> mockprepo = new Mock<IPatient>();
            Mock<IPatProvider> mockpprovider = new Mock<IPatProvider>();
            PatientProvider p = new PatientProvider(mockprepo.Object);
            PatientsController pc = new PatientsController(mockpprovider.Object);
            mockprepo.Setup(r => r.GetPatientById(1)).Returns(p1);
            mockpprovider.Setup(r => r.GetPatientById(1)).Returns(p1);

        }
       
    //    [Test]
    //    public void GetDoctorbyIdTest()
    //    {
    //        Mock<IDoctor> mockdrepo = new Mock<IDoctor>();
    //        Mock<IDocProvider> mockdprovider = new Mock<IDocProvider>();
    //        DocProvider d = new DocProvider(mockdrepo.Object);
    //        mockdrepo.Setup(r => r.GetDoctorById(1)).Returns(d1);
    //        mockdprovider.Setup(r => r.GetDoctorById(1)).Returns(d1);
    //        DoctorsController dc = new DoctorsController(mockdprovider.Object);

    //        var obj = dc.GetDoctorById(1) as OkObjectResult;
    //        Assert.AreEqual(200, obj.StatusCode);

    //    }
    //    [Test]
    //    public void GetPatientbyIdTest()
    //    {
    //        Mock<IPatient> mockprepo = new Mock<IPatient>();
    //        Mock<IPatProvider> mockpprovider = new Mock<IPatProvider>();
    //        PatientProvider p = new PatientProvider(mockprepo.Object);
    //        mockprepo.Setup(r => r.GetPatientById(1)).Returns(p1);
    //        mockpprovider.Setup(r => r.GetPatientById(1)).Returns(p1);
    //        PatientsController pc = new PatientsController(mockpprovider.Object);

    //        var obj = pc.GetPatientById(1) as OkObjectResult;
    //        Assert.AreEqual(200, obj.StatusCode);

    //    }
    }
}
