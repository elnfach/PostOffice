using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostOffice.src
{
    internal class AddressWrap : Dadata.Model.Address
    {
        string data;
        public AddressWrap(IList<Dadata.Model.Suggestion<Dadata.Model.PostalUnit>> suggestions) 
        {
            int counter = 0;
            data = "{\n" +
                "\"suggestions\": [\n";
                
            foreach (var item in suggestions)
            {
                counter++;
                data += "\t{\n";
                data += $"\t\"value\": {item.value},\n";
                data += $"\t\"unrestricted_value\": {item.unrestricted_value},\n";
                data += "\t\"data\": {\n";
                data += $"\t\t\"postal_code\":{item.data.postal_code},\n";
                data += $"\t\t\"is_closed\":{item.data.is_closed},\n";
                data += $"\t\t\"type_code\":{item.data.type_code} ,\n";
                data += $"\t\t\"address_str\":{item.data.address_str} ,\n";
                data += $"\t\t\"address_kladr_id\":{item.data.address_kladr_id} ,\n";
                data += $"\t\t\"address_qc\":{item.data.address_qc}  ,\n";
                data += $"\t\t\"geo_lat\":{item.data.geo_lat}   ,\n";
                data += $"\t\t\"geo_lon\":{item.data.geo_lon}  ,\n";
                data += $"\t\t\"schedule_mon\":{item.data.schedule_mon}  ,\n";
                data += $"\t\t\"schedule_tue\":{item.data.schedule_tue}  ,\n";
                data += $"\t\t\"schedule_wed\":{item.data.schedule_wed}  ,\n";
                data += $"\t\t\"schedule_thu\":{item.data.schedule_thu}  ,\n";
                data += $"\t\t\"schedule_fri\":{item.data.schedule_fri}  ,\n";
                data += $"\t\t\"schedule_sat\":{item.data.schedule_sat}  ,\n";
                data += $"\t\t\"schedule_sun\":{item.data.schedule_sun}   \n";
                data += "\t\t}\n";
                if (suggestions.Count > counter)
                {
                    data += "\t},\n";
                }
                else
                {
                    data += "\t}\n";
                }
            }

            data += "]\n";
            data += "}\n";
        }

        public string GetData()
        {
            return data;
        }
    }
}
