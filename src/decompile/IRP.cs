using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace decompile
{
    internal interface ITaskReuslt
    {
        ulong ErrorCode { get; }

        string ErrorString { get; }

        string ToString();
    }
    internal class TaskResult : ITaskReuslt
    {
        public ulong ErrorCode { get; }

        public string ErrorString { get; }

        protected TaskResult(ulong errorcode, string errorstr)
        {
            ErrorCode = errorcode;
            ErrorString = errorstr;
        }

        public override string ToString()
        {
            return $"errorcode: {ErrorCode} errorstr: {ErrorString}";
        }
    }

    internal sealed class TaskResultFactory : TaskResult
    {
        private TaskResultFactory(ulong v0, string v1) : base(v0, v1) { }

        public static TaskResult Create(ulong errorcode, string errorstr) => new TaskResultFactory(errorcode, errorstr);
    }

    internal interface IIRPContext
    {
        string Tag { get; }
    }
    internal class IRPContext : IIRPContext
    {
        public string Tag {  get; }

        public IRPContext(string tag)
        {
            Tag = tag;
        }
    }
}
