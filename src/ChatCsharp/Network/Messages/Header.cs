using System;

namespace Chat.Network.Messages
{
    [Flags]
    public enum Header : byte 
    {
        // PURPOSE bits
        PURPOSE_CTC     =   0b00000000, 
        PURPOSE_AUTH    =   0b00100000,
        PURPOSE_EXIT    =   0b01000000, 
        PURPOSE_MSGRQST =   0b01100000, 
        PURPOSE_ERRMSG  =   0b10000000,

        // ERROR bits 
        ERROR_NO        =   0b00000000, 
        ERROR_YES       =   0b00010000
    }
}
