# MementoPattern-Basic-Loadout-Prototype
Memento Pattern kullanarak, sürükle bırak yaparak farklı Gear loadout'ları oluşturup save edebileceğimiz basit bir yapıyı içeren repo'dur.<br><br>

GearStorage.cs => Basic Storage sınıfıdır. List şeklinde tanımlanan Slot'lara Start metodunda yine list şeklinde tanımlanan Item'ları yerleştirir. SwapItem metoduyla Item'ların Drag&Drop işlemlerini gerçekleştirir.<br>
UISlot.cs => Storage'daki slotları temsil eden sınıftır. GetStorage metodu ile slot'un içinde bulunduğu GearStorage alınabilir. UpdateUI metodu ile slot'un görseli güncellenir. SetupMouseDrag metodu ile bu slot'a Drag&Drop işlevi eklenir.<br>
MouseDrag.cs => Drag&Drop Input takibini yapan sınıftır. Unity Built-in DragHandler interfacelerini kullanır. OnBeginDrag metodu ile drag başlatılan item'i yakalar ve bir ghost Icon spawn eder. OnDrag metodu ile mouse position takip eder. OnEndDrag metodu ile de Drop edilen Slot'u SwapItem metoduna gönderir.<br>


