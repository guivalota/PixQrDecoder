using System.ComponentModel;

public enum EnumMapeamentoISO20022
{
    [Description("Payload Format Indicator")]
    IndicadoorformatoPaylot = 00,
    [Description("qrEstaticoOuDinamico")]
    qrEstaticoOuDinamico = 01,
    [Description("Informações de Conta do Comerciante - Cartão")]
    ContaComercianteCartao = 04,
    [Description("Informações de Conta do Comerciante - PIX")]
    ContaComerciantePix = 26,
    [Description("Informações de Conta do Comerciante - Outros")]
    ContaComercianteOutros = 07,
    [Description("Categoria de Código do Comerciante")]
    CategoriaComerciante = 52,
    [Description("Moeda da Transação")]
    MoedaTransacao = 53,
    [Description("Valor")]
    Valor = 54,
    [Description("Código do país")]
    CodigoPais = 58,
    [Description("Nome do Comerciante")]
    NomeComerciante = 59,
    [Description("Cidade do Comerciante")]
    CidadeComerciante = 60,
    [Description("Codigo Postal")]
    CodigoPosta = 61,
    [Description("Campos Adicionais")]
    CamposAdicionais = 62,
    [Description("CRC16")]
    CRC16 = 63,
    [Description("Url")]
    Url = 80
}

public enum EnumContaComerciante
{
    [Description("GUI")]
    brgovbcbpix = 00,
    [Description("Chave")]
    Chave = 01,
    [Description("Informação Adicional")]
    InfoAdicional = 02,
    [Description("Instituição")]
    Instituicao = 21,
    [Description("Tipo de Conta")]
    TipoConta = 22,
    [Description("Agência")]
    Agencia = 23,
    [Description("Conta")]
    Conta = 24
}

public enum EnumCamposAdicionais
{
    [Description("GUI")]
    brgovbcbpix = 00,
    [Description("Numero Invoice")]
    InvoiceNumber = 01,
    [Description("Numero Mobile")]
    NumeroMobile = 02,
    [Description("Store Label")]
    SotreLabe = 03,
    [Description("Numero do Layout")]
    NumeroLayout = 04,
    [Description("Referencia")]
    Referencia = 05,
    [Description("Consumer Label")]
    ConsumerLabel = 06,
    [Description("Terminal Label")]
    TerminalLabel = 07,
    [Description("Motivo da Transação")]
    MotivoTransacao = 08,
    [Description("Informações adicionais do cliente")]
    AdditionalCustomerData = 09,
    [Description("Reservado EMV")]
    Reservado = 10
}

public enum EnumUrl
{
   [Description("GUI")]
    brgovbcbpix = 00,
    [Description("UrlQr")]
    UrlQr = 01
}