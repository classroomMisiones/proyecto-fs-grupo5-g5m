using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading;
//using WebApiSegura.Models;
//using WebApiSegura.Security;
using ProyectoWallet.Models;
using System.Web.Http.Cors;

namespace ProyectoWallet.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    /// <summary>
    /// login controller class for authenticate users
    /// </summary>
    [AllowAnonymous]
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        [HttpGet]
        [Route("echoping")]
        public IHttpActionResult EchoPing()
        {
            return Ok(true);
        }
        [HttpGet]
        [Route("echouser")]
        public IHttpActionResult EchoUser()
        {
            var identity = Thread.CurrentPrincipal.Identity;
            return Ok($" IPrincipal-user: {identity.Name} - IsAuthenticated: { identity.IsAuthenticated} ");
        }

        [HttpPost]
        [Route("authenticate")]
        public IHttpActionResult Authenticate(LoginRequest ologin)
        {
            if (ologin == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            
            // Llamo a la funcion del UsuarioController y verifico los datos
            var oGetLoginUsuarios = new UsuariosController();
            // Obtengo la respuesta en un string
            var respuesta = oGetLoginUsuarios.GetLoginUsuarios(ologin);
            // Verifico y genero el tocken
            if (respuesta == "Usuario") {
                    var rolename = "2021/G-5/Ke-Púa/usuario";
                    var token = TokenGenerator.GenerateTokenJwt(ologin.Mail, rolename);
                    return Ok(token);
            }
            if (respuesta == "Administrador")
            {
                var rolename = "2021/G-5/Ke-Púa/administrador";
                var token = TokenGenerator.GenerateTokenJwt(ologin.Mail, rolename);
                return Ok(token);
            }
            // Unauthorized access
            return Unauthorized();
        }
    }
}

//TODO: This code is only for demo - extract method in new class & validate
//correctly in your application !!
//var isUserValid = (login.Mail == "Usuario@usuario" && login.Clave == "123456AAa");
//if (isUserValid)
//{
//    var rolename = "Usuario";
//    var token = TokenGenerator.GenerateTokenJwt(login.Mail, rolename);
//    return Ok(token);
//}
//TODO: This code is only for demo - extract method in new class & validate
//correctly in your application !!
//var isTesterValid = (login.Mail == "test" && login.Clave == "123456");
//if (isTesterValid)
//{
//    var rolename = "Tester";
//    var token = TokenGenerator.GenerateTokenJwt(login.Mail, rolename);
//    return Ok(token);
//}
//TODO: This code is only for demo - extract method in new class & validate
//correctly in your application !!
//var isAdminValid = (login.Mail == "admin" && login.Clave == "123456");
//if (isAdminValid)
//{
//    var rolename = "Administrator";
//    var token = TokenGenerator.GenerateTokenJwt(login.Mail, rolename);
//    return Ok(token);
//}