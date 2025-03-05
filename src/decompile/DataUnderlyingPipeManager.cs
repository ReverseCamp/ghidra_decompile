using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace decompile
{
    internal class AsyncTaskBind<T>
    {
        protected CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        protected CancellationToken cancellationToken;

        public bool IsCancel => cancellationTokenSource.IsCancellationRequested;
        public AsyncTaskBind()
        {
            if (cancellationToken == null)
            {
                cancellationToken = cancellationTokenSource.Token;
            }
        }

        public void DoCancelTask()
        {
            cancellationTokenSource.Cancel();
        }
    }

    internal class DataUnderlyingPipeManager : AsyncTaskBind<DataUnderlyingPipeManager>
    {

        public DataUnderlyingPipeManager()
        {

        }

        public async Task<ITaskReuslt> RunAsync(IIRPContext ctx)
        {
            return await Task.Run(async () =>
            {
                int flag = Convert.ToInt32(ctx.Tag);
                if (flag < 10)
                    await Task.Delay(1000);
                else if (flag < 20)
                    await Task.Delay(2000);
                else if (flag < 30)
                    await Task.Delay(3000);
                else 
                    await Task.Delay(4000);

                if (IsCancel) 
                {
                    DoCancelTask();
                }
                
                return TaskResultFactory.Create((ulong)flag,$"success");
            },cancellationToken);
        }
    }
}
