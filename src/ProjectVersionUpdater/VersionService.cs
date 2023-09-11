using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjectVersionUpdater
{
    public class VersionService
    {
        private readonly string _path;

        public VersionService(string path)
        {
            _path = path;
        }
        public void UpdateMajorVersion(string versionFromFile)
        {
            var finalVersion = MajorVersionBuilder(versionFromFile);
            WriteToFile(finalVersion);
        }
        public void UpdateMinorVersion(string versionFromFile)
        {
            var finalVersion = MinorVersionBuilder(versionFromFile);
            WriteToFile(finalVersion);
        }

        public void WriteToFile(string finalVersion)
        {
            File.WriteAllText(_path, finalVersion);
        }

        public string MinorVersionBuilder(string versionFromFile)
        {
            var patternToGetMinorVersion = @"\.(\d+)$";
            var patternToGetVersion = @"(.*)\.\d+\.";
            var matchMinorVersion = Regex.Match(versionFromFile, patternToGetMinorVersion);
            var matchPatternVersion = Regex.Match(versionFromFile, patternToGetVersion);

            var minorVersion = matchMinorVersion.Groups[1].Value;
            var restOfVersion = matchPatternVersion.Value;

            var minorVersionNumber = int.Parse(minorVersion);
            minorVersionNumber++;
            var incrementedVersionNumberAsString = minorVersionNumber.ToString();
            var finalVersion = String.Concat(restOfVersion, incrementedVersionNumberAsString);
            return finalVersion;
        }
        public string MajorVersionBuilder(string versionFromFile)
        {
            var patternToGetMajorVersion = @"^\d+\.\d+\.(\d+)\.\d+$";
            var patternToGetVersion = @"^(\d+\.\d+\.)";

            var matchMajorVersion = Regex.Match(versionFromFile, patternToGetMajorVersion);
            var matchPatternVersion = Regex.Match(versionFromFile, patternToGetVersion);

            var majorVersion = matchMajorVersion.Groups[1].Value;
            var beginingVersion = matchPatternVersion.Groups[1].Value;

            var majorVersionNumber = int.Parse(majorVersion);
            majorVersionNumber++;
            var majorVersionAsString = majorVersionNumber.ToString();
            var finalVersion = String.Concat(beginingVersion, majorVersionAsString, ".0");
            return finalVersion;
        }
    }
}
