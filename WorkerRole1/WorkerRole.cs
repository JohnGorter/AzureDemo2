using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.Storage;
using DataLayer;
using Microsoft.WindowsAzure.Storage.Table;

namespace WorkerRole1
{
    public class WorkerRole : RoleEntryPoint
    {
        private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private readonly ManualResetEvent runCompleteEvent = new ManualResetEvent(false);

        public override void Run()
        {
            Trace.TraceInformation("WorkerRole1 is running");

            try
            {
                this.RunAsync(this.cancellationTokenSource.Token).Wait();
            }
            finally
            {
                this.runCompleteEvent.Set();
            }
        }

        public override bool OnStart()
        {
            // Set the maximum number of concurrent connections
            ServicePointManager.DefaultConnectionLimit = 12;

            // For information on handling configuration changes
            // see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.

            bool result = base.OnStart();

            Trace.TraceInformation("WorkerRole1 has been started");

            return result;
        }

        public override void OnStop()
        {
            Trace.TraceInformation("WorkerRole1 is stopping");

            this.cancellationTokenSource.Cancel();
            this.runCompleteEvent.WaitOne();

            base.OnStop();

            Trace.TraceInformation("WorkerRole1 has stopped");
        }

        private async Task RunAsync(CancellationToken cancellationToken)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=johngorterstorage;AccountKey=xdhjkxTF/41XKK32cgsdxBKx7rbsICPCgo/IVMdkTyPNaZ1fH8OA8Mmz60G7KPF70XqHBUpObT5paAYTyXE79Q==");

            CloudTableClient tableclient = storageAccount.CreateCloudTableClient();
            CloudTable table = tableclient.GetTableReference("registrations");

            // TODO: Replace the following with your own logic.
            while (!cancellationToken.IsCancellationRequested)
            {
                using (var db = new TrainingDatabase())
                {

                    TableQuery<RegistrationEntity> query = new TableQuery<RegistrationEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "registrations"));
                    var result = table.ExecuteQuery(query);
                    foreach (var mes in result)
                    {
                        Training t = db.Trainings.Where(tr => tr.id.ToString().Equals(mes.training)).FirstOrDefault();
                        if (t != null)
                        {
                            t.registrations.Add(new Registration() { training = t, StudentName = mes.student });
                            db.SaveChanges();
                            Trace.TraceInformation("registration: " + mes.student + " for class " + t.name + " processed..");

                            // delete message
                            table.Execute(TableOperation.Delete(mes));
                        }
                    }
                    Trace.TraceInformation("Working");
                    await Task.Delay(1000);
                }
            }
        }
    }
}
