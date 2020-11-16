# EnterwellProject

Prije pokretanja projekta treba obratiti pažnju da je connection string u **Web.config** datoteci ispravno podešen, na primjer:
```
  <connectionStrings>
    <add name="DefaultConnection" connectionString="Data Source=localhost;Initial Catalog=Projekat;Integrated Security=True"
      providerName="System.Data.SqlClient" />
  </connectionStrings>
```

Nakon konfigurisanja istog, potrebno je izvršiti migracije koristeći Package Manager Console, unosom sljedeće komande:
```
Update-Database
```

----
Napomena: Poslije kreiranja fakture, aplikacija automatski daje opciju za unos stavki, uključujući opis, količinu i cijenu bez PDVa.
