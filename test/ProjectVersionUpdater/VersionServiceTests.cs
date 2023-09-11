using ProjectVersionUpdater;
using Xunit;

namespace ProjectVersionUpdaterTest;

public class VersionServiceTests
{
    [Fact]
    public void MinorVersionBuilder_GivenAppVersion_ReturnsCorrectNewMinorVersion()
    {
        var version = "1.0.1.0";
        var expectedVersion = "1.0.1.1";
        var path = "testPath";
        var service = new VersionService(path);

        var result = service.MinorVersionBuilder(version);

        Assert.Equal(expectedVersion, result);
    }

    [Fact]
    public void MajorVersionBuilder_GivenAppVersion_ReturnsCorrectNewMajorVersion()
    {
        var version = "1.0.1.10";
        var expectedVersion = "1.0.2.0";
        var path = "testPath";
        var service = new VersionService(path);

        var result = service.MajorVersionBuilder(version);

        Assert.Equal(expectedVersion, result);
    }
}