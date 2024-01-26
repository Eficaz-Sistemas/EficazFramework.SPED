namespace EficazFramework.SPED.Interfaces;


internal interface ISoapRequest { }

internal interface ISoapResponse<TMessage>
{
    TMessage UnWrap();
}