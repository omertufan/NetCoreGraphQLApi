using netcoregraphqlapi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netcoregraphqlapi.Repository
{
    public interface IMemberRepository
    {
        IEnumerable<Member> GetAll();
        Member GetById(int id);
        Member AddMember(Member model);

    }
    public class MemberRepository : IMemberRepository
    {

        private List<Member> _members;
       
        public MemberRepository()
        {
            _members = new List<Member>
            {
             new Member
                {
                    MemberId = 111111,
                    FirstName = "Ömer",
                    LastName = "Tufan",
                    UserName = "uyeRGHASDFQA",
                    Email="omer@mail.com",
                    ProfilePhoto = "/images/member/profile/photo-1.png",
                    Balance = 500.00m,
                    FormattedBalance="500,00 TL"

                },
                new Member
                {
                    MemberId = 222222,
                    FirstName = "Aykan",
                    LastName = "Cesur",
                    UserName = "uyeXCVVHFHG",
                    Email="aykan@mail.com",
                    ProfilePhoto = "/member/profile/photo-2.png",
                    Balance = 57.50m,
                    FormattedBalance = "57,50 TL"
                },
                new Member
                {
                    MemberId = 333333,
                    FirstName = "Tuğberk",
                    LastName = "Günver",
                    UserName = "uyeKHRTYURTY",
                    Email="tugberk@mail.com",
                    ProfilePhoto = "/images/member/profile/photo-4.png",
                    Balance = 1500.00m,
                    FormattedBalance = "1.500,00 TL"
                },
                new Member
                {
                    MemberId = 444444,
                    FirstName = "Onur",
                    LastName = "Çaylak",
                    UserName = "uyeQYUIYASDK",
                    Email="onur@mail.com",
                    ProfilePhoto = "/images/member/profile/photo-5.png",
                    Balance = 65.78m,
                    FormattedBalance = "65,78 TL"
                }


            };

        }

        public IEnumerable<Member> GetAll()
        {
            return _members.ToList();
        }

        public Member GetById(int id)
        {
            return _members.SingleOrDefault(o => o.MemberId.Equals(id));
        }

        public Member AddMember(Member model)
        {
            Random generator = new Random();
            String id = generator.Next(0, 1000000).ToString("D6");
            model.Balance = 0;
            model.UserName = "uye" + Guid.NewGuid().ToString().ToUpper().Replace("-", "").Substring(0, 8);
            model.FormattedBalance = "0,00 TL";
            model.MemberId = int.Parse(id);
            _members.Add(model);
            return model;
        }
    }
}
