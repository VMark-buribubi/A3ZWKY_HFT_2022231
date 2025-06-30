# Ember és Kisállat Menedzselő Webalkalmazás

Regisztráció + bejelentkezés funkcióval, ember és kisállat menedzselő webalkalmazás CRUD-al, role kezeléssel együtt. SQL adatbázis.

---

## Telepítés és futtatás

1. Nyisd meg az ASP.NET projektet **Visual Studio**-ban.
2. Nyisd meg a **NuGet Package Manager Console-t**, és futtasd a következő parancsot:

    ```bash
    Update-Database
    ```

3. Futtasd az alkalmazást:
    - Parancssorból:

        ```bash
        dotnet run
        ```

    - Vagy Visual Studio-ból indítva.
4. Az API elérhető lesz a megadott `localhost` címen.

---

## Regisztráció

Új felhasználó készítése Email + jelszó kombinációval a **"Register as a new user"** feliratra kattintva.

---

## Admin belépés

- **Email:** `superadmin@gmail.com`  
- **Jelszó:** `almafa123`
