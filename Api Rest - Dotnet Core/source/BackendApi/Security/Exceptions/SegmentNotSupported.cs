namespace Commom.Exceptions
{
    using System;

    /// <summary>
    /// Exception de segmento não encontrado
    /// </summary>
    public class SegmentNotSupported : Exception
    {
        public override string Message => "Segmento não suportado!";
    }
}