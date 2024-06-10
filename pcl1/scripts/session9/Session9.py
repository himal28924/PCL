import sys
from tkinter import Button,messagebox, mainloop
import tkinter as tk

win = tk.Tk()
win.geometry('400*350')
win.title('HI')

combo = tk.Combobox(
    state='readonly',
    values=[
        'Imperative',
        'OOP',
        'Functional',
        'Distributed'
    ])

combo.place(x=50, y=50)
btn = Button(win, text='Show Info', command=lambda: messagebox.showinfo('Paradigm', f'You selected {combo.get()}'))

btn.pack()
win.mainloop()

