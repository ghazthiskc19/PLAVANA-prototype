# **Technical Document**

**Nama Proyek:** PLAVANA-Prototype  
**Tanggal:** 6 Februari 2025  
**Versi Dokumen:** 1.0  

---

### **Alat yang Digunakan**

Berikut adalah daftar alat, pustaka, dan teknologi yang digunakan dalam pengembangan prototipe game *PLAVANA*:

- **Game Engine:** Unity  
  *Unity adalah game engine yang digunakan untuk mengembangkan *PLAVANA*. Unity mendukung pengembangan game 2D dengan menyediakan berbagai tools dan komponen yang memudahkan pembuatan dan pengujian game.*
  
- **Bahasa Pemrograman:** C#  
  *C# digunakan untuk scripting dalam Unity. Dengan C#, pengendalian logika game, input pemain, dan mekanika permainan dapat diimplementasikan dengan baik.*

- **Pustaka/Library:**
  - **Unity 2D Physics**  
    *Digunakan untuk mekanika fisika 2D dalam game, seperti gravitasi dan deteksi tumbukan antara pemain dan platform.*
  - **Cinemachine**  
    *Digunakan untuk kontrol kamera dinamis dalam game, memungkinkan kamera mengikuti karakter utama dengan lancar.*
  - **TextMesh Pro**  
    *Digunakan untuk menampilkan teks dengan kualitas tinggi dan efek visual yang menarik dalam game.*
  - **Post Processing**
    *Digunakan untuk memberikan tambahan dan meningkatkan kualitas visual eefek pada game *

---

### **Mekanika Permainan**

*PLAVANA* menggunakan beberapa mekanika yang membuat gameplay menjadi menantang dan menarik. Berikut adalah deskripsi mekanika permainan yang diimplementasikan:

- **Kontrol Karakter:**  
  Pemain mengendalikan karakter utama, Bhumi, yang bisa bergerak ke kiri, kanan, dan melompat. Karakter akan bergerak secara otomatis mengikuti arah platform, dan pemain harus melakukan lompatan tepat waktu untuk menghindari monster dan jatuh ke bawah.  
  - **Input Pemain:**  
    - Tombol kiri untuk bergerak ke kiri.
    - Tombol kanan untuk bergerak ke kanan.
    - Tombol lompat untuk melompat ke platform berikutnya.

- **Platforming & Kecepatan Meningkat:**  
  Platform muncul secara acak di layar. Seiring berjalannya waktu, kecepatan platform meningkat, memaksa pemain untuk bergerak lebih cepat. Pemain harus menghindari jatuh ke dalam monster yang ada di bawah platform.

- **Monster Penghalang:**  
  Monster berfungsi sebagai penghalang yang memakan platform jika karakter jatuh ke dalamnya. Pemain harus menghindari monster ini agar permainan tidak berakhir.

- **Skor & Game Over:**  
  Skor pemain dihitung berdasarkan seberapa lama mereka bertahan dalam permainan. Permainan berakhir ketika pemain jatuh ke dalam monster.

#### **Flowchart**
Berikut adalah flowchart yang menggambarkan alur kerja implementasi mekanika permainan:
![Flowchart Image](../Assets/Image/Flowchart.jpg)

### **Tantangan Teknis**

Beberapa tantangan teknis yang dihadapi selama pengembangan game *PLAVANA* adalah sebagai berikut:

- **Tantangan 1:** Pengaturan Kontrol Karakter yang Responsif  
  *Karakter utama, Bhumi, harus bisa bergerak dengan responsif dan melompat dengan akurat, terutama ketika kecepatan platform meningkat.*

  **Solusi:**  
  Kami menyesuaikan nilai kecepatan input dan memperkenalkan teknik penghalusan kontrol untuk memastikan karakter bergerak dengan responsif dan tidak terlalu lambat ketika platform bergerak cepat.

- **Tantangan 2:** Penanganan Monster Penghalang yang Dinamis  
  *Monster yang berfungsi sebagai penghalang harus memiliki logika yang fleksibel untuk mengikuti perkembangan level dan menambah tantangan.*

  **Solusi:**  
  Kami menambahkan sistem spawn monster yang lebih dinamis, dengan pengaturan interval waktu dan posisi spawn berdasarkan kecepatan platform. Ini memberikan variasi tantangan yang lebih menarik untuk pemain.

---

### **Hasil Pengujian**

Setelah prototipe pertama selesai, dilakukan beberapa sesi **playtesting** untuk mendapatkan umpan balik dan melihat bagaimana mekanika permainan berjalan.

- **Perbaikan yang Dilakukan:**
  - **Kecepatan Platform:** Banyak pemain menganggap bahwa platform terlalu cepat setelah beberapa waktu, sehingga mereka kesulitan untuk menghindari monster. Kami menyesuaikan kecepatan platform untuk meningkat secara bertahap dan menambah waktu bagi pemain untuk beradaptasi.
  - **Kontrol Karakter:** Beberapa pemain melaporkan bahwa kontrol karakter kurang responsif, terutama saat lompat. Kami meningkatkan pengaturan kontrol agar lebih presisi dan responsif.

Setelah melakukan perbaikan ini, **playtesting** berikutnya menunjukkan bahwa pemain lebih menikmati tantangan yang ditawarkan oleh game, dengan kontrol yang lebih akurat dan kecepatan platform yang lebih bertahap.
