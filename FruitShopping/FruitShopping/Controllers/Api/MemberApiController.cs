using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FruitShopping.Controllers.Api
{
    [Route("api/Member/[action]")]
    [ApiController]
    public class MemberApiController : ControllerBase
    {
        public List<MemberDTO> GetMember()
        {
            return new List<MemberDTO>() 
            { 
                new MemberDTO(){UserName="Jack",Phone="0988345345",Address="新北市土城"},
                new MemberDTO(){UserName="Mary",Phone="0932456781",Address="新北市板橋"},
                new MemberDTO(){UserName="Mark",Phone="0986583924",Address="新北市樹林"}
            };
        }

        public List<OrderHistoryDTO> GetOrderHistory()
        {
            return new List<OrderHistoryDTO>()
            {
                new OrderHistoryDTO(){OrderId="20230823001",OrderDate="2023-08-23",OrderPrice=456,OrderStatus="備貨中"},
                new OrderHistoryDTO(){OrderId="20230823002",OrderDate="2023-08-24",OrderPrice=721,OrderStatus="備貨中"},
                new OrderHistoryDTO(){OrderId="20230823003",OrderDate="2023-08-25",OrderPrice=873,OrderStatus="備貨中"},
                new OrderHistoryDTO(){OrderId="20230823004",OrderDate="2023-08-26",OrderPrice=148,OrderStatus="備貨中"},
            };
        }

        public List<FavoriteListDTO> GetFavoriteList()
        {
            return new List<FavoriteListDTO>()
            {
                new FavoriteListDTO(){ FavoriteImg="/Image/fruit/cherry/p26.jpg",FavoriteName="櫻桃",FavoritePrice=453},
                new FavoriteListDTO(){ FavoriteImg="/Image/fruit/fruitcup/p43.jpg",FavoriteName="水果杯",FavoritePrice=334},
                new FavoriteListDTO(){ FavoriteImg="/Image/fruit/grape/p29.jpg",FavoriteName="葡萄",FavoritePrice=112},
                new FavoriteListDTO(){ FavoriteImg="/Image/fruit/mango/p07.jpg",FavoriteName="芒果",FavoritePrice=238},
                new FavoriteListDTO(){ FavoriteImg="/Image/fruit/pineapple/p20.jpg",FavoriteName="鳳梨",FavoritePrice=449}
            };
        }

        public List<CustomerServiceDTO> GetCustomerService()
        {
            return new List<CustomerServiceDTO>()
            {
                new CustomerServiceDTO(){ CustomerMessage ="價格便宜，好吃",AdminMessage="謝謝"},
                new CustomerServiceDTO(){ CustomerMessage ="包裝漂亮，好看",AdminMessage="謝謝你"},
                new CustomerServiceDTO(){ CustomerMessage ="送貨很快，效率高",AdminMessage="感謝您"},
                new CustomerServiceDTO(){ CustomerMessage ="一般還好，普通",AdminMessage="謝謝惠顧"},
            };
        }
    }
}

public class MemberDTO
{
    public string? UserName { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
}

public class OrderHistoryDTO
{
    public string? OrderId { get; set; } 
    public string? OrderDate { get; set; }
    public int? OrderPrice { get; set; }
    public string? OrderStatus { get; set; }
}

public class FavoriteListDTO
{
    public string? FavoriteImg{ get; set; }
    public string? FavoriteName { get; set; }
    public int FavoritePrice { get; set; }
}

public class CustomerServiceDTO
{
    public string? CustomerMessage { get; set; }
    public string? AdminMessage { get; set; }
}