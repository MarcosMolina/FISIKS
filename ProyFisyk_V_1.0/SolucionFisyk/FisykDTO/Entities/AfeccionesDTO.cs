
namespace FisykDTO
{
    public class AfeccionesDTO : DTOBase
    {
        public int afnId { get; set; }
        public string afnDescripcion { get; set; }//
        public int afn_tafId { get; set; }
        public int afn_zcuId { get; set; }

        public AfeccionesDTO()
        {
            afnId = Int_NullValue;
            afnDescripcion = String_NullValue;
            afn_tafId = Int_NullValue;
            afn_zcuId = Int_NullValue;
            IsNew = true;
        }
    }
}
