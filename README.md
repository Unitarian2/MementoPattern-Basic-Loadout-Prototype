# MementoPattern-Basic-Loadout-Prototype
Memento Pattern kullanarak, sürükle bırak yaparak farklı Gear loadout'ları oluşturup save edebileceğimiz basit bir yapıyı içeren repo'dur.<br><br>

<b>GearStorage.cs</b> => Basic Storage sınıfıdır. List şeklinde tanımlanan Slot'lara Start metodunda yine list şeklinde tanımlanan Item'ları yerleştirir. SwapItem metoduyla Item'ların Drag&Drop işlemlerini gerçekleştirir.<br>
<b>UISlot.cs</b> => Storage'daki slotları temsil eden sınıftır. GetStorage metodu ile slot'un içinde bulunduğu GearStorage alınabilir. UpdateUI metodu ile slot'un görseli güncellenir. SetupMouseDrag metodu ile bu slot'a Drag&Drop işlevi eklenir.<br>
<b>MouseDrag.cs</b> => Drag&Drop Input takibini yapan sınıftır. Unity Built-in DragHandler interfacelerini kullanır. OnBeginDrag metodu ile drag başlatılan item'i yakalar ve bir ghost Icon spawn eder. OnDrag metodu ile mouse position takip eder. OnEndDrag metodu ile de Drop edilen Slot'u SwapItem metoduna gönderir.<br>
<b>PlayerGear.cs</b> => Memento Pattern'i işlediğimiz sınıftır. Bir Memento create edilebilir veya save edilen memento çağırılabilir. Ayrıca spesifik bir Memento Set edilebilir.<br>
<b>GearLoadoutHandler.cs</b> => Oluşturulan Memento'ların yönetildiği sınıftır. Start metodunda her bir loadout için birer Memento oluşturur ve bunları saklar. SelectLoadout metoduyla seçilen Loadout'a ait Memento getirilir. SaveLoadout metoduyla mevcut seçim kaydedilir. <br>
<b>Item.cs</b> => UISlot içerisinde bulunan Item'ları temsit eden sınıftır. Scriptable Object olarak kullanılmıştır, böylece farklı item tipleri tanımlayabiliyoruz.

