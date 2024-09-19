# RedisTemp
 Redis kullanımı

1. In-Memory cache: Veri̇leri̇ uygulamanın çalıştığı bi̇lgi̇sayarın ram'i̇nde cache yaklaşımı
2. Disturbed cache: Veri̇leri̇ bi̇rden fazla fi̇zi̇ksel maki̇nede cachleyen ve böylece farklı noktalarda tutarak daha güvenli̇ hale getirme yaklaşımı.
3. Master Redis sunucusu: Uygulamanın hali hazırda kullandığı redis veritabanıdır.
4. Slave Redis sunucusu: Master sunucuyu dinleyip kopyasını alan redis veritabanıdır. Üzerine yazma yapılamaz. Master'dan sadece 1 tane olurken slave birden fazla olabilir.
5. Sentinel sunucusu: Farklı bir sunucudur. Master sunucusunun sağlıklı olup olmadığını izler. bir sıkıntı olursa sağlıklı olan slave sunucusuna geçiş yapar. slave sunucularını da izleyip hangisi öncelikli ve sağlıklı ise ona geçiş yapar.
6. Failover: Master'da hata oldu diyelim sentinel gelip master'ı bir slave ile değiştirdiği olaya verilen isim.
