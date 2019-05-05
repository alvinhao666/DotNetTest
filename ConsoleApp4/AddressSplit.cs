using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp4
{
    public class AddressSplit
    {


        public static List<string> getAddress(string address)

        {

            string province = "";

            string city = "";

            string district = "";


            string regex = "(?<province>[^省]+省|[^自治区]+自治区|.+市)(?<city>[^自治州]+自治州|.+区划|[^市]+市|[^盟]+盟|[^地区]+地区)?(?<county>[^市]+市|[^县]+县|[^旗]+旗|.+区)?(?<town>[^区]+区|.+镇)?(?<village>.*)";

            //Matcher m = Pattern.compile(regex).matcher(address);

            foreach(Match match in Regex.Matches(address, regex))
            {
                province = match.Groups[1].Value;
                city = match.Groups[2].Value;
                district = match.Groups[3].Value;
            }

            //while (m.find())
            //{

            //    province = m.group("province");

            //}

            return new List<string>(){ province,city,district };

        }

    }
}
