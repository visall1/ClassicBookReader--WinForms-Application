# 📚 Classic Book Reader - WinForms Application

This is a C# Windows Forms application that allows users to **browse**, **read**, and **download** classic books from [Project Gutenberg](https://www.gutenberg.org/). The application features an interactive UI where users can click on book covers to read the content and save it locally as a `.txt` file.

---

## 🚀 Features

- 🖼️ **Dynamic Book Gallery**  
  Displays a scrollable list of book covers using a `FlowLayoutPanel`.

- 📖 **Live Book Preview**  
  Clicking a book cover downloads and displays the book's content inside a `RichTextBox`.

- 💾 **Save to File**  
  Allows the user to export the currently viewed book as a `.txt` file.

- 🖱️ **Custom Window Movement**  
  Users can drag the form window by clicking and dragging a specified panel.

---

## 📚 Included Books

1. *The Adventures of Tom Sawyer* – Mark Twain  
2. *Pride and Prejudice* – Jane Austen  
3. *Moby-Dick* – Herman Melville  
4. *Dracula* – Bram Stoker  
5. *Frankenstein* – Mary Shelley  
6. *Jane Eyre* – Charlotte Brontë  
7. *The Picture of Dorian Gray* – Oscar Wilde  
8. *The Great Gatsby* – F. Scott Fitzgerald  
9. *War and Peace* – Leo Tolstoy  
10. *The Odyssey* – Homer (translated)

All book contents and covers are fetched directly from [Project Gutenberg](https://www.gutenberg.org/).

---

## 🛠️ Technologies Used

- 💻 .NET Framework (WinForms)
- 🌐 `HttpClient` for web requests
- 🖼️ `PictureBox` and `Panel` controls for UI layout
- 📄 File I/O for saving text files
- 🧲 Windows API via `DllImport` to support draggable UI panels

---

## 📦 How to Run

1. Open the solution (`.sln`) file in Visual Studio.
2. Restore NuGet packages if prompted.
3. Build and run the project using `F5`.

---

## 📝 How It Works

- On app launch, the `Form_Load` event initializes the UI and loads book covers.
- Clicking a cover triggers `BookCover_Click`, which:
  - Downloads the book content using `HttpClient`
  - Displays it in `RichTextBox`
- The user can click the **Download** button to save the book locally.
- The custom form drag behavior is handled by the `PanelMoves` utility class via WinAPI.

---

## 📁 Project Structure

```
WindowsFormsApp1/
│
├── Form1.cs               # Main application logic
├── PanelMoves.cs          # Enables custom window dragging
├── Book.cs                # (Expected) Book class model
├── Program.cs             # Entry point
├── Form1.Designer.cs      # Auto-generated UI design code
└── README.md              # You're reading it now!
```

> 📌 Make sure the `Book` class exists and matches the constructor used in `Form1`.

---

## ✅ TODO / Enhancements

- Add a search feature for filtering books.
- Implement text formatting (like font size adjustments).
- Add offline reading mode (caching books).
- UI theme customization (dark/light mode).

---

## 📄 License

This project uses books from Project Gutenberg, which are in the public domain. The code is open-source and free to use for educational purposes.
