using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace decompile
{
    internal class TaskCommand
    {
        public int Id { get; }
        public int ParentId { get; }
        public byte[] Data { get; }

        public bool IsComplete { get; }

        public TaskCommand(byte[] data,bool iscomplete,int id,int pid)
        {
            Data = data;
            IsComplete = iscomplete;
            Id = id;
            ParentId = pid;
        }
    }
}
