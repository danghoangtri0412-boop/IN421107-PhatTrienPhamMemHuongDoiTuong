## Các vi phạm SOLID trong Class ClubManager.cs

1. Từ dòng (35-64).
   - **Nguyên tắc**: SRP một method làm quá quá nhiều việc. Vừa Validate (dòng 38-41), Save (dòng 44-45), Log (dòng 48), Notify (52-63).
   - **Hậu quả**:
     - Sửa phần thông báo có thể làm lỗi phần Validate hoặc phần Log, Save.
     - Không thể test riêng được từng phần.
     - Làm cho hàm dài và khó đọc dễ xung đột nếu nhiều người cùng sửa.

2. Từ dòng (52-63).
   - **Nguyên tắc**: OCP nếu muốn thêm kênh thông báo SMS hay SLACK thì phải sửa code mà nguyên tắc OCP là mở rộng code nhưng không phải sửa code đã có và đang ổn định.
   - **Hậu quả**:
     - Mỗi lần thêm kênh thông báo mới thì lại phải sửa code đang chạy ổn định.
     - Làm cho code thông báo dài và khó đọc khi có nhiều kênh thông báo.

3. Từ dòng (67-84).
   - **Nguyên tắc**: SRP và OCP
     - **SRP**: Method vừa kiểm tra câu lạc bộ và giới hạng thành viên (dòng 69-73), thêm thành viên mới (dòng 75-76), ghi Log (dòng 79), gửi thông báo (dòng 82-83).
     - **OCP**: Muốn thêm thông báo thì phải sửa code ở 2 dòng này dòng (82-83).
   - **Hậu quả**:
     - Khi thay đổi quy tắc quản lý thành viên, cách ghi log hoặc gửi thông báo phải sửa cùng một method, làm cho code khó bảo trì.
     - Khi thêm kênh thông báo mới phải sửa lại code có thể làm ảnh hưởng đến các chức năng đang hoạt động bình thường và khó mở rộng khi có nhiều kênh thông báo.

4. Các dòng (48, 79, 94, 111)
   - **Nguyên tắc**: DIP module mức cao không nên phụ thuộc vào module mức thấp ở đây các dòng ghi log gọi thẳng module ở mức thấp là 'System.IO.File'thay vì phụ thuộc vào một abstract.
   - **Hậu quả**:
     - Muốn đổi phương thức ghi Log khác hoặc hệ thống logging khác có thể sửa lại ở nhiều nơi.
     - Phần ghi log bị phân tán ở nhiều chỗ dẫn đến việc bảo trì, kiểm thử khó khăn hơn.
