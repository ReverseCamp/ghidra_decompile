using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace decompile
{
    internal enum Protocol
    {
        CommandRequestHeader,
        CommandRequestCloser,
        CommandResponseHeader,
        CommandResponseCloser,
        JavaExceptionResponseHeader,
        JavaExceptionResponseCloser,
        RegisterProgramResponseHeader,
        RegisterProgramResponseCloser,
        StringHeader,
        StringCloser,
        BadCommandResponseHeader,
        BadCommandResponseCloser,
    }

    internal sealed class ProtocolConst
    {
        public Dictionary<Protocol, byte[]> protocolBytes = new Dictionary<Protocol, byte[]>()
        {
            {Protocol.CommandRequestHeader, new byte[4] { 0x00,0x00,0x01,0x04      } },
            {Protocol.CommandRequestCloser, new byte[4] { 0x00,0x00,0x01,0x05      } },
            {Protocol.CommandResponseHeader, new byte[4] { 0x00,0x00,0x01,0x06      } },
            {Protocol.CommandResponseCloser, new byte[4] { 0x00,0x00,0x01,0x07      } },
            {Protocol.JavaExceptionResponseHeader, new byte[4] { 0x00,0x00,0x01,0x12      } },
            {Protocol.JavaExceptionResponseCloser, new byte[4] { 0x00,0x00,0x01,0x13      } },
            {Protocol.RegisterProgramResponseHeader, new byte[4] { 0x00,0x00,0x01,0x16      } },
            {Protocol.RegisterProgramResponseCloser, new byte[4] { 0x00,0x00,0x01,0x17      } },
            {Protocol.StringHeader, new byte[4] { 0x00,0x00,0x01,0x16      } },
            {Protocol.StringCloser, new byte[4] { 0x00,0x00,0x01,0x17      } },
            {Protocol.BadCommandResponseHeader, new byte[4] { 0x00,0x00,0x01,0x20   } },
            {Protocol.BadCommandResponseCloser, new byte[4] { 0x00,0x00,0x01,0x21   } },
        };
    }
}
