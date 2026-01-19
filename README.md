# Eshop For Fun 🛒

Eshop For Fun je vzdělávací backendový projekt postavený na **ASP.NET Core Web API**, jehož cílem je **pochopit a správně aplikovat principy REST API a práci s databází**.

Projekt neslouží jako hotový komerční e-shop, ale jako **tréninkové hřiště**. Za mentoring děkuju Radkovi. 

---

## 🎯 Cíl projektu

Hlavním cílem projektu je:

- naučit se **navrhovat čisté REST API**
- pochopit **tok dat (request → validace → logika → databáze → response)**
- pracovat s **Entity Framework Core**
- správně používat **HTTP metody a stavové kódy**

---

## 🧩 Funkční doména

Projekt simuluje jednoduchý e-shop se základními entitami:

### 🗂️ Kategorie
- Kategorie slouží k organizaci produktů
- Produkt **musí vždy patřit do existující kategorie**
- API kontroluje, zda je možné produkt do dané kategorie uložit

### 📦 Produkty
- Produkt má název, cenu, vazbu na kategorii
- API umožňuje:
  - vytvoření produktu
  - úpravu produktu (PUT / PATCH)
  - smazání produktu
  - získání jednoho nebo více produktů

---

## 🌐 REST API principy

Projekt klade důraz na **správné REST chování**:

- jasně definované routy (`/api/products`, `/api/categories`)
- správné použití HTTP metod:
  - `GET` – čtení dat
  - `POST` – vytváření
  - `PUT` – úplná aktualizace
  - `PATCH` – částečná aktualizace
  - `DELETE` – mazání
- smysluplné HTTP status kódy:
  - `200 OK`
  - `201 Created`
  - `400 Bad Request`
  - `404 Not Found`
  - `409 Conflict`
