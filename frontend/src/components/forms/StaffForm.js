import React from 'react'
import { Form, Input, Select, Button, message } from 'antd'
import { updateStaff, createStaff } from '../../services/staffService';

const { Option } = Select

const StaffForm = ({ ...props }) => {
    const { currentUser, staff } = props
    const handleSubmit = e => {
        e.preventDefault()
        props.form.validateFields((err, values) => {
            if (!err) {
                if (staff.staffId) {
                    updateStaff(staff.staffId, { ...values, staffId: staff.staffId }).then(res => {
                        props.saveUpdateStaff()
                        message.success('Staff has been updated')
                    }).catch(err => {
                        message.error('Update failed')
                    })
                } else {
                    createStaff(values).then(res => {
                        props.saveCreateStaff()
                        message.success('Staff has been created')
                    }).catch(err => {
                        message.error('Create failed')
                    })
                }


            }
        })
    }

    const { getFieldDecorator } = props.form;

    return (
        <Form className="staff-form">
            <Form.Item label="Email">
                {getFieldDecorator('email', {
                    rules: [{ required: true, message: 'Please type staff email!' }],
                })(
                    <Input
                        placeholder="Email"
                        type="email"
                    />,
                )}
            </Form.Item>
            <Form.Item label="Full Name">
                {getFieldDecorator('name', {
                    rules: [{ required: true, message: 'Please type Full Name !' }],
                })(
                    <Input
                        placeholder="Full Name"
                    />,
                )}
            </Form.Item>
            <Form.Item label="Username">
                {getFieldDecorator('username', {
                    rules: [{ required: true, message: 'Please input your username!' }],
                })(
                    <Input
                        placeholder="username"
                    />,
                )}
            </Form.Item>
            <Form.Item label="Password">
                {getFieldDecorator('password', {
                    rules: [{ required: true, message: 'Please input your password!' }],
                })(
                    <Input
                        type="password"
                        placeholder="password"
                    />,
                )}
            </Form.Item>
            <Form.Item label="Phone">
                {getFieldDecorator('phone', {
                    rules: [{ required: true, message: 'Please input your phone!' }],
                })(
                    <Input
                        type="number"
                        placeholder="phone"
                    />,
                )}
            </Form.Item>
            <Form.Item label="Role">
                {getFieldDecorator('role', {
                    rules: [{ required: true, message: 'Please select your status!' }],
                })(
                    <Select placeholder="Please select a status">
                        <Option value="Sales">Sales</Option>
                        <Option value="SalesAdmin">SalesAdmin</Option>
                        <Option value="SalesDepartmentAdmin">SalesDepartmentAdmin</Option>
                    </Select>,
                )}
            </Form.Item>


            <Form.Item>

                <Button
                    type='primary'
                    style={{ marginLeft: 8 }}
                    onClick={handleSubmit}
                > Submit </Button>

            </Form.Item>
        </Form>
    );

}

const WrappedStaffForm = Form.create({
    name: 'staff_form',
    onFieldsChange(props, changedFields) {
        // props.onChange(changedFields)
    },
    mapPropsToFields(props) {
        return {
            email: Form.createFormField({
                ...props.staff.email,
                value: props.staff.email
            }),
            name: Form.createFormField({
                ...props.staff.name,
                value: props.staff.name
            }),
            username: Form.createFormField({
                ...props.staff.username,
                value: props.staff.username
            }),
            password: Form.createFormField({
                ...props.staff.password,
                value: props.staff.password
            }),
            phone: Form.createFormField({
                ...props.staff.phone,
                value: props.staff.phone
            }),
            role: Form.createFormField({
                ...props.staff.role,
                value: props.staff.role
            })

        }
    },
    onValuesChange(_, values) {
        // console.log(values)
    }
})(StaffForm)

export default WrappedStaffForm