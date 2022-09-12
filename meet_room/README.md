Cookie Scheme
GET http://localhost/login -> HomeController.Login()
POST http://localhost/login -> Redirect to /app
GET http://localhost -> HomeController.Index() -> Аутентификация (Authentication)

Header scheme 
	(Bearer): Header -> "Authentication": Bearer ПРОПУСК
	(ПРОПУСК/TOKEN): JWT (Json Web Token)

GET http://localhost/app -> ClientApp (logged-in user)
	-> /api/getevents
	-> /api/saveevent

() -> (authentication) -> () ->


(authentication) -> что в запросе -> HttpContext.User = new User()

				// User:
					role: "admin,editor"
					authorized: "facebook"


					1. Cookie - сохраняется
						Много разных страниц
					2. Header - существует в рамка запроса - SPA
						Одна страница -> получение пропуска -> отправка пропуска в AJAX запросе
