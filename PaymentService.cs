using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace digitalparking
{

    public class PaymentService
    {
        public decimal CalculateParkingFee(ParkingSession session)
        {
            TimeSpan elapsed = session.ExitTime - session.EntryTime;
            int elapsedTime = (int)elapsed.TotalMinutes;

            decimal fee = session.InitialFee;
            int tolerance = 5;

            if (elapsedTime > session.ContractedMinutes + tolerance)
            {
                if (session.ContractedMinutes == 30)
                {
                    fee += AdditionalFee(elapsedTime - session.ContractedMinutes);
                    return fee;
                }

                else if (session.ContractedMinutes == 60)
                {
                    fee += AdditionalFee(elapsedTime - session.ContractedMinutes);
                    return fee;
                }

                else if (session.ContractedMinutes == 120)
                {
                    fee += AdditionalFee(elapsedTime - session.ContractedMinutes);
                    return fee;
                }

                else
                {
                    fee += AdditionalFee(elapsedTime - session.ContractedMinutes);
                    return fee;
                }
            }

            else
            {
                return fee;
            }
        }

        public decimal AdditionalFee(int additional)
        {
            decimal additionalFee = 0;

            while (additional > 0)
            {
                if (additional <= 30)
                {
                    additionalFee += 9;
                    additional -= 30;
                }

                else if (additional <= 60)
                {
                    additionalFee += 12;
                    additional -= 60;
                }

                else if (additional <= 120)
                {
                    additionalFee += 21;
                    additional -= 120;
                }

                else
                {
                    additionalFee += 33;
                    additional -= 180;
                }
            }

            return additionalFee;

        }
    }
}