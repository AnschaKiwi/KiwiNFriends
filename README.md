📘 README – Kiwi n Friends (Zelda Style Project)
Stand: 9. Juli 2025

🎮 Aktuelle Features
🛏️ Startsequenz mit „Schlaf“-Animation
→ Heldin wacht erst nach Leertaste auf
→ Sanfter Übergang: Sleep → StandUp → LookAround → Idle

🔐 Bewegung gesperrt, bis Aufwachvorgang abgeschlossen ist
→ Spielerin kann erst nach „Idle“ herumlaufen

🔦 Selbstgebaute Taschenlampe
→ Weinbecher + Spotlight
→ Ein- und ausschaltbar mit Taste F
→ Flackert gelegentlich für Stimmung

☀️🌙 Tag-Nacht-Zyklus (60 Sek. Testlauf oder 25/15 Minuten real)
→ Sonne wandert über den Himmel
→ Lichtfarbe und Intensität passen sich an
→ Kann später auf echten Rhythmus erweitert werden

🕰️ Uhrzeit-Anzeige oben rechts (TextMeshPro)
→ Zeigt aktuelle Spielzeit (z. B. 09:01) basierend auf Tageszeit
→ Canvas auf „Screen Space - Overlay“

🧩 Technik & Struktur
Animator mit Trigger-basiertem Einstieg (Aufsteher)

Bewegung wird erst durch StateMachineBehaviour (BewegungFreigeben.cs) freigegeben

Klar getrennte UI:

Overlay-Canvas für HUD (Uhrzeit)

World-Canvas optional für spätere Sprechblasen

📌 Nächste Schritte (optional)
🗨️ Sprechblase bei „LookAround“ anzeigen („Was passiert … wo bin ich?“)

🎨 Optische Deko: Ruine / Startgebiet aufbauen

🕰️ Später: Analoge Uhr mit echten Zeigern im UI

🔧 Aufsteh-Animation noch feintunen (z. B. langsamer, natürlicher)
