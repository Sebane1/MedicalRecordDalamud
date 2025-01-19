using Dalamud.IoC;
using Dalamud.Plugin.Services;
using MedicalRecordDalamud.MedicalConditions;
using RoleplayingMedicalRecordCore.MedicalManagment;
using SamplePlugin;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace MedicalRecordDalamud
{
    public class MedicalRecordManager
    {
        private MedicalManager _medicalRecord;
        Stopwatch stopwatch = new Stopwatch();
        public MedicalRecordManager()
        {
            Task.Run(() =>
            {
                Plugin.Framework.Update += Framework_Update;
                _medicalRecord = new MedicalManager();
                _medicalRecord.MedicalConditions.Add(new Lactosis());
            });
            stopwatch.Start();
        }

        private void Framework_Update(IFramework framework)
        {
            if (Plugin.ClientState.IsLoggedIn)
            {
                if (stopwatch.ElapsedMilliseconds > 400)
                {
                    _medicalRecord.CheckMedicalConditions();
                    stopwatch.Restart();
                }
            }
        }
    }
}
