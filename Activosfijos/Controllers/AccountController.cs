using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Activosfijos.Models;

namespace Activosfijos.Controllers
{

    [Authorize]
    public class AccountController : Controller
    {
        //
        // GET: /Account/Index

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Account/Login

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        //
        // POST: /Account/Login

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.UserName, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "El nombre de usuario o la contrase�a especificados son incorrectos.");
                }
            }

            // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
            return View(model);
        }

        //
        // GET: /Account/LogOff

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/Register

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Intento de registrar al usuario
                MembershipCreateStatus createStatus;
                Membership.CreateUser(model.UserName, model.Password, model.Email, passwordQuestion: null, passwordAnswer: null, isApproved: true, providerUserKey: null, status: out createStatus);

                if (createStatus == MembershipCreateStatus.Success)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, createPersistentCookie: false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", ErrorCodeToString(createStatus));
                }
            }

            // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
            return View(model);
        }

        //
        // GET: /Account/ChangePassword

        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Account/ChangePassword

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {

                // ChangePassword iniciar� una excepci�n en lugar de
                // devolver false en determinados escenarios de error.
                bool changePasswordSucceeded;
                try
                {
                    MembershipUser currentUser = Membership.GetUser(User.Identity.Name, userIsOnline: true);
                    changePasswordSucceeded = currentUser.ChangePassword(model.OldPassword, model.NewPassword);
                }
                catch (Exception)
                {
                    changePasswordSucceeded = false;
                }

                if (changePasswordSucceeded)
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "La contrase�a actual es incorrecta o la nueva contrase�a no es v�lida.");
                }
            }

            // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
            return View(model);
        }

        //
        // GET: /Account/ChangePasswordSuccess

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }

        #region C�digos de estado
        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // Vaya a http://go.microsoft.com/fwlink/?LinkID=177550 para
            // obtener una lista completa de c�digos de estado.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "El nombre de usuario ya existe. Escriba un nombre de usuario diferente.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "Ya existe un nombre de usuario para esa direcci�n de correo electr�nico. Escriba una direcci�n de correo electr�nico diferente.";

                case MembershipCreateStatus.InvalidPassword:
                    return "La contrase�a especificada no es v�lida. Escriba un valor de contrase�a v�lido.";

                case MembershipCreateStatus.InvalidEmail:
                    return "La direcci�n de correo electr�nico especificada no es v�lida. Compruebe el valor e int�ntelo de nuevo.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "La respuesta de recuperaci�n de la contrase�a especificada no es v�lida. Compruebe el valor e int�ntelo de nuevo.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "La pregunta de recuperaci�n de la contrase�a especificada no es v�lida. Compruebe el valor e int�ntelo de nuevo.";

                case MembershipCreateStatus.InvalidUserName:
                    return "El nombre de usuario especificado no es v�lido. Compruebe el valor e int�ntelo de nuevo.";

                case MembershipCreateStatus.ProviderError:
                    return "El proveedor de autenticaci�n devolvi� un error. Compruebe los datos especificados e int�ntelo de nuevo. Si el problema contin�a, p�ngase en contacto con el administrador del sistema.";

                case MembershipCreateStatus.UserRejected:
                    return "La solicitud de creaci�n de usuario se ha cancelado. Compruebe los datos especificados e int�ntelo de nuevo. Si el problema contin�a, p�ngase en contacto con el administrador del sistema.";

                default:
                    return "Error desconocido. Compruebe los datos especificados e int�ntelo de nuevo. Si el problema contin�a, p�ngase en contacto con el administrador del sistema.";
            }
        }

        #endregion
    }
}
