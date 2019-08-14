import React from 'react'
import { Form, Icon, Input, Button, message } from 'antd'
import { connect } from 'react-redux'
import { login } from '../../services/authService'
import { updateCurrentUser } from '../../actions/actionCreator'

const LoginForm = ({ ...props }) => {
    const { updateCurrentUser } = props
    const handleSubmit = e => {
        e.preventDefault()
        props.form.validateFields((err, values) => {
            if (!err) {
                login(values).then(res => {
                    localStorage.setItem('token',JSON.stringify(res.token))
                    updateCurrentUser(res)
           
                }).catch(err => {
                    message.error('Login failed!')
                })
            }
        })
    }

    const { getFieldDecorator } = props.form;
    return (
        <Form onSubmit={handleSubmit} className="login-form">
            <Form.Item>
                {getFieldDecorator('username', {
                    rules: [{ required: true, message: 'Please input your username!' }],
                })(
                    <Input
                        prefix={<Icon type="user" style={{ color: 'rgba(0,0,0,.25)' }} />}
                        placeholder="Username"
                    />,
                )}
            </Form.Item>
            <Form.Item>
                {getFieldDecorator('password', {
                    rules: [{ required: true, message: 'Please input your Password!' }],
                })(
                    <Input
                        prefix={<Icon type="lock" style={{ color: 'rgba(0,0,0,.25)' }} />}
                        type="password"
                        placeholder="Password"
                    />,
                )}
            </Form.Item>
            <Form.Item>
                <Button type="primary" htmlType="submit" className="login-form-button">
                    Log in
                </Button>

            </Form.Item>
        </Form>
    );

}

const mapStateToProps = (state, props) => {
    return {
        currentUser: state.authReducer.user,
        isAuthenticated: state.authReducer.isAuthenticated
    }
}

const mapDispatchToProps = {
    updateCurrentUser
}

const WrappedNormalLoginForm = connect(
    mapStateToProps,
    mapDispatchToProps)(
        Form.create({ name: 'login_form' })(LoginForm)
    )

export default WrappedNormalLoginForm