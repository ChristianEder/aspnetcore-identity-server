using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;

namespace aspnetcore_identity_server.IdentityServer
{
    public static class IdentityServerSigning
    {
        public static RsaSecurityKey SecurityKey
        {
            get
            {
                const string rsaJson = "{\"D\":\"FWSZOjZZilTQoWHDXVPSQj3UJTJXgReLvk2dh9L6mfCH5i+4UQHtV+ilNlHVxV+58dQ/W6bMdCNjMrBWsEm2WfjuL0ojSspEJVQDrzbwqfUUPy3Pdpzrsdp/pfLFZjnVSW8MIqLg7+TyfKGG/UCJ7wONz1NIF/lmddXCAaCtoRxOMLzAMXti8lNkEmNp9so+6XnvefzaFeFolkq5NSQwPS7WYkr7r1uYylkKvVECcMWdmvR+Tms/tNSB4Ro4omxser/weYF3Z/lBsWUAkh0Gyhpzs9roMvy9pITdXNdP9Pih6ynNL2YR9QO8rOFDMY7lQHJyZ67TwSDKDHqad8usrw==\",\"DP\":\"CYpCsLvV6YBJdKJ5TJpSCIixzGpbEheaa6VZ4Qe27dQMZMXjSoVJ4cwGZarIuSnDLyDBgwY+dAWVFVFgGjEhhIg1FsiZ5B4cKPem3grUPyAdY6o8/TgdTWwbaFOeF9Ptr42hQygzDnzyINmceD5uWPyocoGUQpqvefqfIsxnrmM=\",\"DQ\":\"+S40wv1dWNYcmNzse/cDhYf8C6jZk96/KSD88NdIPp1eLvb2XuiOo7P9fyZiUCXR1w1nLLmTEUOyZNRUjrr/0oPZskKPgA82291JS11OTSv/73DEDvtdxPUmTizqmkV3EsmjQ4I1QlUSeOrlbLHEkljqUcLccehf/K6oI2Hqb68=\",\"Exponent\":\"AQAB\",\"InverseQ\":\"F6XdSYZVMbccF1ywbLxZr9qKcFlObVmyxctXDU9poDJId1uJmqRjkY0XYSXHI1lE4NWCmXbs0bO5QWjuWLxpHDY8bcs1XC8wl3l7XgaCLkz3qgdFfXXOftAdMe1ffneZabigedWJYFM11EswdO+6kdR9BWkgH/b5D8OMPbmxrXU=\",\"Modulus\":\"439rhEc+WB6j/ds2m3Kqfm9+aYQsM7fzOjDUWn5r/7b3lyOOy0MX+24h+kwXCQqne2MAwByxt2yXQwEk5/HR8o2PCTbgeb9OhvC1Biq2E5UAzpBK9F06H/q+zwkeVJyHFUn4d96HfevzzC/rrZgTiFhuD3TYxtd0c5JNR3gbmd+PvAwzzzdrgSwnGmyHVJk6GHmw5ilaeupBn3w8ITleQy8jh//jO0RxQaXnEY6LlMYFC7lZx1gNrEgxw0gIW8UuWebV6p1SU9A4nP79PTQcDITXWEyiDWJtIhNRJqLviCB4EnwJQ/IgewEBU/yNYrOaQqPrLiMmNS5VfqfrczYOqQ==\",\"P\":\"5JpG2xOfh0XSmJBTx82zs4CLwdzx6Hm62hHtUL1yDrF9ONep7MW5VsKFolJn5IbRkDv2/mLLU8bRwGTZHWmmHG3aRxus8v1PwXTki8/qd6gQFC7cqVWxtLBsPm884fS46HElm5vdzmQ2FSEqM2C+5HtQU07KYi7O6+KGu1jfaD8=\",\"Q\":\"/sM+X9VRE6y+wDkE97wrQwxXw5pXZJk576JpdwJTHc2ss2bGcDXrzQjyWaBG4+eleW7vEDB/pmBh7XTG+m1RVGfOFlNnRocN9lgEihiyGMtIm3AAUYh0pjKIhp3PYKLBq98hz6yVLLwXI7J3vMZdMHxFQutLIvGyuea1Ct34Dxc=\"}";
                var rsa = Newtonsoft.Json.JsonConvert.DeserializeObject<RSAParameters>(rsaJson);
                return new RsaSecurityKey(rsa);
            }
        }
    }
}
