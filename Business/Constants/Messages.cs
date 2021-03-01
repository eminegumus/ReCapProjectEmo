using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba başarıyla eklenmiştir.";
        public static string InvalidCarName = "Araba ismi en az 2 karakter olmalıdır.";
        public static string CarListed = "Arabalar Listelendi.";
        public static string CustomerAdded= "Müşteri başarıyla eklendi.";
        public static string InvalidUser = "Önce kullanıcı girişi yapmalısınız!";
        public static string UndeliveredCar = "Araba henüz teslim edilmediğinden kiralama işlemi gerçekleştirilememektedir.";
        public static string CarImageLimitExceeded = "En fazla 5 resim ekleyebilirsiniz!";
        public static string AuthorizationDenied = "Yetkiniz Bulunmamaktadır.";
        public static string UserRegistered = "Kullanıcı Kayıtlı";
        public static string UserNotFound = "Kullanıcı Bulunamadı";
        public static string PasswordError = "Parola Hatalı";
        public static string SuccessfulLogin = "Başarılı giriş.";

        public static string UserAlreadyExists = "Kullanıcı daha önce oluşturulmuş.";
        public static string AccessTokenCreated = "AccessToken oluşturuldu.";
    }
}
